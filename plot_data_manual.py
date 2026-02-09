import pandas as pd
import plotly.graph_objects as go
from plotly.subplots import make_subplots

# 1. Load the data
df = pd.read_csv('simu.csv', sep=';')

# 2. Convert TimeStamp to datetime and sort (recommended)
df['TimeStamp'] = pd.to_datetime(df['TimeStamp'], unit='s')
df = df.sort_values('TimeStamp')

# 3. Compute a reasonable bar width (for datetime x-axis)
if len(df) >= 2:
    deltas_ms = df['TimeStamp'].diff().dropna().dt.total_seconds() * 1000
    bar_width_ms = float(deltas_ms.median()) * 0.8
else:
    bar_width_ms = 3600 * 1000 * 0.8  # fallback: ~1 hour

# 4. Create the interactive figure
fig = make_subplots(specs=[[{"secondary_y": True}]])

# =========================================================
# OPTION A: Add BARS FIRST so they render BEHIND the lines
# =========================================================

# --- Y2 Axis: Quantity (Bars) ---
fig.add_trace(
    go.Bar(
        x=df['TimeStamp'],
        y=df['Qty'],
        name='Qty',
        width=bar_width_ms,          # thicker bars on datetime axis
        opacity=0.9,                 # visibility
        marker=dict(
            color='rgba(150, 150, 150, 0.1)',
            line=dict(color='rgba(150, 150, 150, 0.1)', width=2)
        ),
        offsetgroup=0
    ),
    secondary_y=True
)

# --- Y1 Axis: PriceNew (Line) ---
fig.add_trace(
    go.Scatter(
        x=df['TimeStamp'],
        y=df['PriceNew'],
        name='PriceNew',
        mode='lines+markers',
        marker=dict(symbol='circle', size=6, color='orange'),
        line=dict(width=2, color='orange')
    ),
    secondary_y=False
)

# 5. Configure Layout
fig.update_layout(
    hovermode=False,
    updatemenus=[
        dict(
            type="buttons",
            direction="left",
            x=1.0,
            y=1.0,
            xanchor="right",
            yanchor="bottom",
            pad=dict(r=10, t=10),
            showactive=True,
            buttons=[
                dict(
                    label="Toggle tooltips",
                    method="relayout",
                    args=[{"hovermode": False}],
                    args2=[{"hovermode": "x unified"}],
                )
            ],
        )
    ],
    
    title=dict(text='Price vs Quantity Over Time (Interactive)'),
    bargap=0.02,
    xaxis=dict(
        title=dict(text='Timestamp'),
        showgrid=False,
        rangeslider=dict(visible=True),
    ),

    # Left Y-Axis (Price)
    yaxis=dict(
        title=dict(text='Price', font=dict(color='blue')),
        tickfont=dict(color='blue'),
        showgrid=False,
    ),

    # Right Y-Axis (Quantity)
    yaxis2=dict(
        title=dict(text='Quantity', font=dict(color='gray')),
        tickfont=dict(color='gray'),
        showgrid=False,
        layer='below traces'
    ),

    template='plotly_white'
)

# 6. Show the plot
fig.show()
